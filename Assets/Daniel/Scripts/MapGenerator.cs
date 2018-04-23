using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour
{
    public Transform MapBorder;
    public GameObject SurfaceToBake;

    public Vector2 MaxMapSize;
    public Vector2 MinMapSize;

    [Range(0, 1)] public float OutlinePercent;
    [Range(0, 1)] public float ObstaclePercent;
    public float TileSize;


    private List<Coord> _allTileCoords;
    private Queue<Coord> _shuffledTileCoords;

    public int Seed = 10;
    private Coord _mapCentre;
    [SerializeField] private Vector2 _mapSize;

    public bool Generate;
    public bool IsRandom;
    
    public GameObject tilePool;
    public GameObject[] ObstaclePool;

    private void Start()
    {
        Generate = true;
        GenerateMap();
    }

    public void GenerateMap()
    {
        Generate = true;
        
        if (Generate)
        {
            RandomiseMapParametres();

            GetTileCoordinates();

            var mapHolder = MapHolder();

            mapHolder.parent = transform;

            SpawnTiles(mapHolder);

            SpawnObstacles(mapHolder);

            PlaceNavMeshMask(mapHolder);
        }

        Generate = false;
    }

    private Transform MapHolder()
    {
        const string holderName = "Generated Map";

        if (transform.Find(holderName))
            DestroyImmediate(transform.Find(holderName).gameObject);


        var mapHolder = new GameObject(holderName).transform;
        return mapHolder;
    }

    private void GetTileCoordinates()
    {
        _allTileCoords = new List<Coord>();

        for (var x = 0; x < _mapSize.x; x++)
        {
            for (var y = 0; y < _mapSize.y; y++)
            {
                _allTileCoords.Add(new Coord(x, y));
            }
        }

        _shuffledTileCoords = new Queue<Coord>(Utility.ShuffleArray(_allTileCoords.ToArray(), Seed));
        _mapCentre = new Coord((int) _mapSize.x / 2, (int) _mapSize.y / 2);
    }

    private void SpawnTiles(Transform mapHolder)
    {
        for (var x = 0; x < _mapSize.x; x++)
        {
            for (var y = 0; y < _mapSize.y; y++)
            {
               
                var tilePosition = CoordToPosition(x, y);

                GameObject newTile = Instantiate(tilePool, tilePosition, Quaternion.Euler(Vector3.right * 90));

                newTile.transform.localScale = Vector3.one * (1 - OutlinePercent) * TileSize;
                
                newTile.transform.parent = mapHolder;
            }
        }
    }

    private void SpawnObstacles(Transform mapHolder)
    {
        var obstacleMap = new bool[(int) _mapSize.x, (int) _mapSize.y];
        var obstacleCount = (int) (_mapSize.x * _mapSize.y * ObstaclePercent);
        var currentObstacleCount = 0;

        for (var i = 0; i < obstacleCount; i++)
        {
            var randomCoord = GetRandomCoord();
            obstacleMap[randomCoord.X, randomCoord.Y] = true;
            currentObstacleCount++;

            if (randomCoord != _mapCentre && MapIsFullyAccessible(obstacleMap, currentObstacleCount))
            {
               var randomobjpicked = Random.RandomRange(0, ObstaclePool.Length);
                    
                var obstaclePosition = CoordToPosition(randomCoord.X, randomCoord.Y);

                var newObstacle = Instantiate(ObstaclePool[randomobjpicked], obstaclePosition + Vector3.up * .5f,
                    Quaternion.identity);
                
                newObstacle.transform.parent = mapHolder;
                
                newObstacle.transform.Rotate(-90,0,0);
                newObstacle.transform.localScale = Vector3.one * (1 - OutlinePercent) * TileSize;
            }
            else
            {
                obstacleMap[randomCoord.X, randomCoord.Y] = false;
                currentObstacleCount--;
            }
        }
    }

    private void RandomiseMapParametres()
    {
        var maxMapSizeX = (int) MaxMapSize.x;
        var maxMapSizeY = (int) MaxMapSize.y;

        var minMapSizeX = (int) MinMapSize.x;
        var minMapSizeY = (int) MinMapSize.y;

        if (!IsRandom) return;
        
        _mapSize.x = Random.Range(minMapSizeX, maxMapSizeX);
        _mapSize.y = Random.Range(minMapSizeY, maxMapSizeY);
        
        Seed = Random.Range(1, 1000);

    }

    private void PlaceNavMeshMask(Transform mapHolder)
    {
        var maskLeft = Instantiate(MapBorder,
            Vector3.left * (_mapSize.x + MaxMapSize.x) / 4 * TileSize,
            Quaternion.identity);
        maskLeft.parent = mapHolder;
        maskLeft.localScale = new Vector3((MaxMapSize.x - _mapSize.x) / 2, 1, _mapSize.y) * TileSize;

        var maskRight = Instantiate(MapBorder,
            Vector3.right * (_mapSize.x + MaxMapSize.x) / 4 * TileSize,
            Quaternion.identity);
        maskRight.parent = mapHolder;
        maskRight.localScale = new Vector3((MaxMapSize.x - _mapSize.x) / 2, 1, _mapSize.y) * TileSize;

        var maskTop = Instantiate(MapBorder,
            Vector3.forward * (_mapSize.y + MaxMapSize.y) / 4 * TileSize,
            Quaternion.identity);
        maskTop.parent = mapHolder;
        maskTop.localScale = new Vector3(MaxMapSize.x, 1, (MaxMapSize.y - _mapSize.y) / 2) * TileSize;

        var maskBottom = Instantiate(MapBorder,
            Vector3.back * (_mapSize.y + MaxMapSize.y) / 4 * TileSize,
            Quaternion.identity);
        maskBottom.parent = mapHolder;
        maskBottom.localScale = new Vector3(MaxMapSize.x, 1, (MaxMapSize.y - _mapSize.y) / 2) * TileSize;
    }

    private bool MapIsFullyAccessible(bool[,] obstacleMap, int currentObstacleCount)
    {
        var mapFlags = new bool[obstacleMap.GetLength(0), obstacleMap.GetLength(1)];
        var queue = new Queue<Coord>();
        queue.Enqueue(_mapCentre);
        mapFlags[_mapCentre.X, _mapCentre.Y] = true;

        var accessibleTileCount = 1;

        while (queue.Count > 0)
        {
            var tile = queue.Dequeue();

            for (var x = -1; x <= 1; x++)
            {
                for (var y = -1; y <= 1; y++)
                {
                    var neighbourX = tile.X + x;
                    var neighbourY = tile.Y + y;
                    if (x == 0 || y == 0)
                    {
                        if (neighbourX >= 0 && neighbourX < obstacleMap.GetLength(0) && neighbourY >= 0 &&
                            neighbourY < obstacleMap.GetLength(1))
                        {
                            if (!mapFlags[neighbourX, neighbourY] && !obstacleMap[neighbourX, neighbourY])
                            {
                                mapFlags[neighbourX, neighbourY] = true;
                                queue.Enqueue(new Coord(neighbourX, neighbourY));
                                accessibleTileCount++;
                            }
                        }
                    }
                }
            }
        }

        var targetAccessibleTileCount = (int) (_mapSize.x * _mapSize.y - currentObstacleCount);
        return targetAccessibleTileCount == accessibleTileCount;
    }

    private Vector3 CoordToPosition(int x, int y)
    {
        return new Vector3(-_mapSize.x / 2 + 0.5f + x, 0, -_mapSize.y / 2 + 0.5f + y) * TileSize;
    }


    private Coord GetRandomCoord()
    {
        var randomCoord = _shuffledTileCoords.Dequeue();
        _shuffledTileCoords.Enqueue(randomCoord);
        return randomCoord;
    }

    public struct Coord
    {
        public int X;
        public int Y;

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Coord c1, Coord c2)
        {
            return c1.X == c2.X && c1.Y == c2.Y;
        }

        public static bool operator !=(Coord c1, Coord c2)
        {
            return !(c1 == c2);
        }
    }
}