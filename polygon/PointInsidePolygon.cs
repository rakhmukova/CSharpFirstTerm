using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInsidePolygon
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int X, int Y)
        {
            this.x = X;
            this.y = Y;
        }
    }

 
 
    public class Program
    {
       
        static public Point MakeVector(Point start, Point end)
        {
            Point vector = new Point(end.x - start.x, end.y - start.y);
            return vector;
        }

        static public int GetVectorProductSign(Point v1, Point v2)
        {
            int value = v1.x * v2.y - v2.x * v1.y;

            if (value > 0)
                return 1;
            if (value < 0)
                return -1;
            return 0;
        }

        static public int GetPointLocation(Point point, Point firstPoint, Point secondPoint)
        {
            Point firstVector = MakeVector(firstPoint, point);
            Point secondVector = MakeVector(point, secondPoint);
            return GetVectorProductSign(firstVector, secondVector);
        }

        static public bool BelongsToBorder(Point p, Point firstEndOfTheBorder, Point secondEndOfTheBorder)
        {            
            int value = GetPointLocation(p, firstEndOfTheBorder, secondEndOfTheBorder);
            if (value ==0)

            {
                if (firstEndOfTheBorder.x != secondEndOfTheBorder.x && 
                    (p.x >= firstEndOfTheBorder.x && p.x <= secondEndOfTheBorder.x || p.x <= firstEndOfTheBorder.x && p.x >= secondEndOfTheBorder.x))
                    return true;

                if (firstEndOfTheBorder.x == secondEndOfTheBorder.x && 
                    (p.y >= firstEndOfTheBorder.y && p.y <= secondEndOfTheBorder.y || p.y <= firstEndOfTheBorder.y && p.y >= secondEndOfTheBorder.y))
                    return true;
            }                
            return false;
        }
      

        static public bool RayAndBorderHaveCommonPoints (Point startPoint, Point rayPoint, Point firstEnd, Point secondEnd) 
        {
            int startPointLocation = GetPointLocation(startPoint, firstEnd, secondEnd);
            int rayPointLocation = GetPointLocation(rayPoint, firstEnd, secondEnd);
            if (startPointLocation == rayPointLocation && !(startPointLocation == 0 && startPoint.x <= firstEnd.x)) 
                return false;                
            
            return true;           
        } 

        static public int GetTheNumberOfCrossings(int [] VerticesLocations, int currentNumber)
        {
            int previousVerticeLocation = VerticesLocations[(currentNumber - 1) % 4];
            int firstEndLocation = VerticesLocations[currentNumber % 4];
            int secondEndLocation = VerticesLocations[(currentNumber + 1) % 4];
            int nextVerticeLocation = VerticesLocations[(currentNumber + 2) % 4];

            if (firstEndLocation == secondEndLocation && firstEndLocation == 0)
            {
                if (previousVerticeLocation == nextVerticeLocation)
                    return 0;
                else
                    return 1;
            }

            if (firstEndLocation == 0)
                return 0;

            // Учитываем одну и ту же вершину два раза, сначала в качестве firstEnd, затем secondEnd, если она принадлежит лучу.
            if (secondEndLocation == 0 && (firstEndLocation == nextVerticeLocation || nextVerticeLocation == 0))
                return 0;

            if (firstEndLocation == secondEndLocation)
                return 0;
            
            return 1;
        }

        static public bool BelongsToPolygon(int[] coordinatesOfThePoint, int[,] verticesCoordinates)
        {

            Point keyPoint = new Point(coordinatesOfThePoint[0], coordinatesOfThePoint[1]);
            int N = verticesCoordinates.GetUpperBound(0);
            Point[] PolygonVertices = new Point[N];
            int maximumXCordinate = verticesCoordinates[0,0];
            int xCoordinate;
            for (int i = 0; i < N; i++)
            {
                PolygonVertices[i] = new Point(verticesCoordinates[i, 0], verticesCoordinates[i, 1]);
                xCoordinate = PolygonVertices[i].x;
                if (xCoordinate > maximumXCordinate)
                    maximumXCordinate = xCoordinate;
            }            

            if (keyPoint.x > maximumXCordinate)
                return false;

            Point pointOfTheRay = new Point(maximumXCordinate + 10, keyPoint.y); 
            // Направляем луч горизонтально вправо.
            int theNumberOfCrossings = 0;

            Point previousVertice = PolygonVertices[0];
            Point firstEnd = PolygonVertices[1];
            Point secondEnd = PolygonVertices[2];
            Point nextVertice;

            int previousVertexLocation = GetPointLocation(previousVertice, keyPoint, pointOfTheRay);
            int firstEndLocation = GetPointLocation(firstEnd, keyPoint, pointOfTheRay);
            int secondEndLocation = GetPointLocation(secondEnd, keyPoint, pointOfTheRay);
            int nextVertexLocation; 

            int[] PointsLocations = new int[4] { previousVertexLocation, firstEndLocation, secondEndLocation, 0};
            int currentNumberOfCrossings;

            for (int vertexNumber = 1; vertexNumber < N + 1; vertexNumber++)
            {   
                
                firstEnd = PolygonVertices[(vertexNumber) % N];
                secondEnd = PolygonVertices[(vertexNumber + 1) % N];
                nextVertice = PolygonVertices[(vertexNumber + 2) % N];

                if (BelongsToBorder(keyPoint, firstEnd, secondEnd))
                    return true;

                nextVertexLocation = GetPointLocation(nextVertice, keyPoint, pointOfTheRay);
                PointsLocations[(vertexNumber + 2) % 4] = nextVertexLocation;

                if (RayAndBorderHaveCommonPoints(keyPoint, pointOfTheRay, firstEnd, secondEnd))
                {
                    currentNumberOfCrossings = GetTheNumberOfCrossings (PointsLocations, vertexNumber);
                    theNumberOfCrossings += currentNumberOfCrossings;
                }                                   
            }
            
            if (theNumberOfCrossings % 2 == 0)
                return false;
            else
                return true;
        }

        //static void ElimiateImaginaryVertices(int[,] coordinates)
        //{

        //}

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество вершин многоугольника");
            int theNumberOfVertices = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите координаты вершин многоугольника");
            int[,] polygonVerticesCoordinates = new int[theNumberOfVertices, 2];
            string[] coordinatesOfThePoint = new string[2];
            for (int i = 0; i < theNumberOfVertices; i++)
            {
                coordinatesOfThePoint = Console.ReadLine().Split();
                polygonVerticesCoordinates[i, 0] = int.Parse(coordinatesOfThePoint[0]);
                polygonVerticesCoordinates[i, 1] = int.Parse(coordinatesOfThePoint[1]);
            }

            Console.WriteLine("Введите координаты точки");
            coordinatesOfThePoint = Console.ReadLine().Split();
            int[] coordinates = {int.Parse(coordinatesOfThePoint[0]), int.Parse(coordinatesOfThePoint[1])};

            if (BelongsToPolygon(coordinates, polygonVerticesCoordinates))
                Console.WriteLine("Точка принадлежит многоугольнку");
            else
                Console.WriteLine("Точка не принадлежит многоугольнику");
            Console.ReadLine();
        }
    }
}
