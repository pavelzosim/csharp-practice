using System;

namespace csharp_learn
{
    // LESSON 27: Multidimensional Arrays (Matrices)
    // Learn how to work with 2D arrays (matrices) for grids, maps, and tables
    internal class Lesson27_arrays_matrix
    {
        public static void Run()
        {
            // ===== TOPIC: MULTIDIMENSIONAL ARRAYS (2D ARRAYS) =====
            // 2D array = array with rows and columns (like a table or grid)
            // Syntax: type[,] name - rectangular array (all rows same length)
            // Used for: Game maps, grids, matrices, tables, images

            Console.WriteLine("=== MULTIDIMENSIONAL ARRAY BASICS ===\n");

            // ===== DECLARING MULTIDIMENSIONAL ARRAYS =====

            // Method 1: Declaration only (not initialized)
            int[,] array;

            // Method 2: Create with size (all elements = 0)
            int[,] array2 = new int[2, 3];  // 2 rows, 3 columns
            Console.WriteLine($"array2 dimensions: {array2.GetLength(0)} rows x {array2.GetLength(1)} columns");
            Console.WriteLine($"array2 total elements: {array2.Length}");  // 2 * 3 = 6

            // Method 3: Initialize with values
            int[,] array3 = {
                { 2, 3, 4 },  // Row 0
                { 4, 5, 1 },  // Row 1
                { 7, 8, 9 }   // Row 2
            };

            // Method 4: Create with size and initialize
            int[,] array4 = new int[2, 3] {
                { 9, 8, 7 },  // Row 0
                { 6, 5, 4 }   // Row 1
            };

            Console.WriteLine();

            // ===== ACCESSING ELEMENTS =====

            Console.WriteLine("=== ACCESSING ELEMENTS ===\n");

            // Access specific element: array[row, column]
            Console.WriteLine($"array3[0, 0] = {array3[0, 0]}");  // 2 (row 0, col 0)
            Console.WriteLine($"array3[1, 2] = {array3[1, 2]}");  // 1 (row 1, col 2)
            Console.WriteLine($"array3[2, 1] = {array3[2, 1]}");  // 8 (row 2, col 1)

            // Modify element
            array3[1, 1] = 99;
            Console.WriteLine($"After modification, array3[1, 1] = {array3[1, 1]}");  // 99

            Console.WriteLine();

            // ===== ARRAY PROPERTIES AND METHODS =====

            Console.WriteLine("=== ARRAY PROPERTIES ===\n");

            int[,] matrix = new int[5, 5];

            // GetLength(dimension) - returns size of specific dimension
            int rows = matrix.GetLength(0);     // Number of rows (5)
            int cols = matrix.GetLength(1);     // Number of columns (5)
            Console.WriteLine($"Rows: {rows}, Columns: {cols}");

            // Length - total number of elements
            Console.WriteLine($"Total elements: {matrix.Length}");  // 5 * 5 = 25

            // Rank - number of dimensions
            Console.WriteLine($"Dimensions (Rank): {matrix.Rank}");  // 2 (2D array)

            Console.WriteLine();

            // ===== ITERATING WITH NESTED LOOPS =====

            Console.WriteLine("=== POPULATING AND DISPLAYING MATRIX ===\n");

            Random rand = new Random();

            // Fill matrix with random values
            for (int i = 0; i < matrix.GetLength(0); i++)  // Rows
            {
                for (int j = 0; j < matrix.GetLength(1); j++)  // Columns
                {
                    matrix[i, j] = rand.Next(0, 10);  // Random 0-9
                }
            }

            // Display matrix
            Console.WriteLine("5x5 Matrix:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");  // Tab for alignment
                }
                Console.WriteLine();  // New line after each row
            }

            Console.WriteLine();

            // ===== MATRIX OPERATIONS =====

            Console.WriteLine("=== MATRIX OPERATIONS ===\n");

            // Example matrix
            int[,] matrixA = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            // 1. Find sum of all elements
            int sum = 0;
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    sum += matrixA[i, j];
                }
            }
            Console.WriteLine($"Sum of all elements: {sum}");

            // 2. Find maximum element
            int max = matrixA[0, 0];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    if (matrixA[i, j] > max)
                    {
                        max = matrixA[i, j];
                    }
                }
            }
            Console.WriteLine($"Maximum element: {max}");

            // 3. Find minimum element
            int min = matrixA[0, 0];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    if (matrixA[i, j] < min)
                    {
                        min = matrixA[i, j];
                    }
                }
            }
            Console.WriteLine($"Minimum element: {min}");

            // 4. Calculate sum of each row
            Console.WriteLine("\nSum of each row:");
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                int rowSum = 0;
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    rowSum += matrixA[i, j];
                }
                Console.WriteLine($"Row {i}: {rowSum}");
            }

            // 5. Calculate sum of each column
            Console.WriteLine("\nSum of each column:");
            for (int j = 0; j < matrixA.GetLength(1); j++)
            {
                int colSum = 0;
                for (int i = 0; i < matrixA.GetLength(0); i++)
                {
                    colSum += matrixA[i, j];
                }
                Console.WriteLine($"Column {j}: {colSum}");
            }

            // 6. Sum of main diagonal (top-left to bottom-right)
            int diagonalSum = 0;
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                diagonalSum += matrixA[i, i];  // [0,0], [1,1], [2,2]
            }
            Console.WriteLine($"\nMain diagonal sum: {diagonalSum}");

            Console.WriteLine();

            // ===== MATRIX TRANSPOSE =====

            Console.WriteLine("=== MATRIX TRANSPOSE ===\n");

            int[,] original = {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };

            // Create transposed matrix (swap rows and columns)
            int[,] transposed = new int[original.GetLength(1), original.GetLength(0)];

            for (int i = 0; i < original.GetLength(0); i++)
            {
                for (int j = 0; j < original.GetLength(1); j++)
                {
                    transposed[j, i] = original[i, j];
                }
            }

            Console.WriteLine("Original matrix:");
            PrintMatrix(original);

            Console.WriteLine("\nTransposed matrix:");
            PrintMatrix(transposed);

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: GRID MAP =====

            Console.WriteLine("=== GAME MAP GRID ===\n");

            // 0 = empty, 1 = wall, 2 = player, 3 = enemy, 4 = treasure
            int[,] gameMap = {
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 3, 0, 1 },
                { 1, 0, 1, 1, 1, 0, 1 },
                { 1, 2, 0, 0, 0, 4, 1 },
                { 1, 1, 1, 1, 1, 1, 1 }
            };

            Console.WriteLine("Game Map:");
            for (int i = 0; i < gameMap.GetLength(0); i++)
            {
                for (int j = 0; j < gameMap.GetLength(1); j++)
                {
                    switch (gameMap[i, j])
                    {
                        case 0:
                            Console.Write(". ");  // Empty
                            break;
                        case 1:
                            Console.Write("# ");  // Wall
                            break;
                        case 2:
                            Console.Write("P ");  // Player
                            break;
                        case 3:
                            Console.Write("E ");  // Enemy
                            break;
                        case 4:
                            Console.Write("T ");  // Treasure
                            break;
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            // ===== 3D ARRAYS =====

            Console.WriteLine("=== 3D ARRAYS ===\n");

            // 3D array - like a cube (layers, rows, columns)
            int[,,] cube = new int[2, 3, 4];  // 2 layers, 3 rows, 4 columns

            Console.WriteLine($"3D array dimensions: {cube.GetLength(0)} x {cube.GetLength(1)} x {cube.GetLength(2)}");
            Console.WriteLine($"Total elements: {cube.Length}");  // 2 * 3 * 4 = 24

            // Fill and display 3D array
            int value = 1;
            for (int layer = 0; layer < cube.GetLength(0); layer++)
            {
                Console.WriteLine($"\nLayer {layer}:");
                for (int row = 0; row < cube.GetLength(1); row++)
                {
                    for (int col = 0; col < cube.GetLength(2); col++)
                    {
                        cube[layer, row, col] = value++;
                        Console.Write($"{cube[layer, row, col]}\t");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            Console.WriteLine("=== MULTIDIMENSIONAL ARRAY BEST PRACTICES ===\n");

            // TIP 1: RECTANGULAR vs JAGGED ARRAYS
            // Rectangular [,]: Better memory layout, faster access
            // Jagged [][]: More flexible (rows can have different lengths)

            // RECTANGULAR (faster, better cache locality):
            int[,] rectangular = new int[100, 100];

            // JAGGED (more flexible, but slower):
            int[][] jagged = new int[100][];
            for (int i = 0; i < 100; i++)
            {
                jagged[i] = new int[100];
            }

            // Use rectangular [,] for: Fixed grids, matrices, game maps
            // Use jagged [][] for: Variable row lengths, triangular data

            // TIP 2: CACHE GetLength() - CRITICAL!
            // INEFFICIENT - GetLength() called every iteration:
            // for (int i = 0; i < array.GetLength(0); i++) { }  // Slow

            // EFFICIENT - Cache dimensions:
            int cachedRows = matrix.GetLength(0);
            int cachedCols = matrix.GetLength(1);
            for (int i = 0; i < cachedRows; i++)
            {
                for (int j = 0; j < cachedCols; j++)
                {
                    // Process faster
                }
            }
            // PERFORMANCE GAIN: ~10-15% for large matrices

            // TIP 3: ROW-MAJOR ORDER (Cache-Friendly)
            // EFFICIENT - Iterate rows first (cache-friendly):
            // for (int row = 0; row < rows; row++) {
            //     for (int col = 0; col < cols; col++) {
            //         array[row, col] = value;  // Sequential memory access
            //     }
            // }

            // INEFFICIENT - Iterate columns first (cache-unfriendly):
            // for (int col = 0; col < cols; col++) {
            //     for (int row = 0; row < rows; row++) {
            //         array[row, col] = value;  // Jumping memory access
            //     }
            // }

            // TIP 4: PRE-ALLOCATE MATRICES
            // GAME DEV: Create game map once at startup, not every frame
            // INEFFICIENT:
            // void Update() {
            //     int[,] temp = new int[10, 10];  // Allocates every frame!
            // }

            // EFFICIENT:
            // int[,] map = new int[10, 10];  // Allocate once
            // void Update() {
            //     // Reuse map
            // }

            // TIP 5: MULTIDIMENSIONAL ARRAY LIMITATIONS
            // Cannot resize (fixed size)
            // All rows must have same length
            // For dynamic grids, consider List<List<T>> or jagged arrays

            // TIP 6: FOREACH WITH 2D ARRAYS
            // foreach iterates ALL elements (no row/column info)
            int[,] testMatrix = { { 1, 2 }, { 3, 4 } };
            Console.WriteLine("Using foreach (no row/column info):");
            foreach (int element in testMatrix)
            {
                Console.Write($"{element} ");  // 1 2 3 4
            }
            Console.WriteLine("\n");

            Console.WriteLine("⚡ PERFORMANCE TIPS:");
            Console.WriteLine("• Rectangular [,] faster than jagged [][] (better cache locality)");
            Console.WriteLine("• Cache GetLength(0) and GetLength(1) before loops");
            Console.WriteLine("• Iterate rows FIRST for cache efficiency");
            Console.WriteLine("• Pre-allocate matrices - don't create in loops");
            Console.WriteLine("• Use for loops, not foreach (need row/column indices)");

            Console.WriteLine("\n🚀 GAME DEV OPTIMIZATION:");
            Console.WriteLine("• Use [,] for game maps, grids, tile systems");
            Console.WriteLine("• Pre-allocate map at startup, not every frame");
            Console.WriteLine("• Cache dimensions - don't call GetLength repeatedly");
            Console.WriteLine("• Row-major iteration (rows first) is cache-friendly");
            Console.WriteLine("• For large worlds, consider chunking (split into smaller grids)");

            Console.WriteLine("\n✅ BEST PRACTICES SUMMARY:");
            Console.WriteLine("• Use [,] for fixed-size grids and matrices");
            Console.WriteLine("• Use [][] for variable row lengths");
            Console.WriteLine("• Always cache GetLength(0) and GetLength(1)");
            Console.WriteLine("• Iterate row-major order (rows first, then columns)");
            Console.WriteLine("• Use for loops (need indices), not foreach");
            Console.WriteLine("• Pre-allocate matrices for performance");
            Console.WriteLine("• Check bounds to avoid IndexOutOfRangeException");

            Console.WriteLine("\n📋 COMMON MATRIX OPERATIONS:");
            Console.WriteLine("• Create: int[,] matrix = new int[rows, cols];");
            Console.WriteLine("• Initialize: int[,] m = { {1,2}, {3,4} };");
            Console.WriteLine("• Access: int value = matrix[row, col];");
            Console.WriteLine("• Rows: int rows = matrix.GetLength(0);");
            Console.WriteLine("• Columns: int cols = matrix.GetLength(1);");
            Console.WriteLine("• Total: int total = matrix.Length;");
            Console.WriteLine("• Iterate: for (i < rows) for (j < cols)");

            Console.WriteLine("\n🎮 GAME DEV USE CASES:");
            Console.WriteLine("• Tile-based maps: int[,] map = new int[width, height];");
            Console.WriteLine("• Chess/checkers board: Piece[,] board = new Piece[8, 8];");
            Console.WriteLine("• Pathfinding grids: bool[,] walkable = new bool[w, h];");
            Console.WriteLine("• Fog of war: bool[,] visible = new bool[w, h];");
            Console.WriteLine("• Heightmaps: float[,] heights = new float[w, h];");
            Console.WriteLine("• Minimap data: Color[,] pixels = new Color[w, h];");

            Console.WriteLine("\n❌ COMMON MISTAKES:");
            Console.WriteLine("• Not caching GetLength (slow in nested loops)");
            Console.WriteLine("• Column-major iteration (cache-unfriendly)");
            Console.WriteLine("• Creating matrices in Update/loop (allocations)");
            Console.WriteLine("• Confusing [row, col] order");
            Console.WriteLine("• Using foreach when you need row/column indices");
            Console.WriteLine("• Forgetting to check bounds");
            Console.WriteLine("• Using [,] when rows have different lengths (use [][])");
        }

        // Helper method to print matrix
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}