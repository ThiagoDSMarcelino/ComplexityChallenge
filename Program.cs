using System.Diagnostics;
using System.Text;

int seed = DateTime.Now.Millisecond;
Random rand = new Random(seed);

MostrarTempo(1000, 20);

int solucao1(int[,] mat, int N)
{
    return Search.BinarySolution(mat, N);
}

int solucao2(int[,] mat, int N)
{
    return -1;
}

int solucao3(int[,] mat, int N)
{
    return -1;
}

int solucao4(int[,] mat, int N)
{
    return -1;
}


int[,] GerarMatrizCebola(int N)
{
    int[,] mat = new int[N, N];
    int x = rand.Next(N),
        y = rand.Next(N),
        value = rand.Next(500, 1000),
        _x = 0,
        _y = 0;
    mat[x, y] = value;

    int delta = 1;
    int lastMinValue = value;
    int newMinValue = value;
    while (delta < N)
    {
        for (int i = -delta; i <= delta; i++)
        {
            var newValue = lastMinValue - rand.Next(1, 6);
            if (newValue < newMinValue)
                newMinValue = newValue;
            
            _x = x + i;
            _y = y - delta;
            if (_x < 0 || _x >= N || _y < 0 || _y >= N)
                continue;
            
            mat[_x, _y] = newValue;
        }
        
        for (int i = -delta; i <= delta; i++)
        {
            var newValue = lastMinValue - rand.Next(1, 6);
            if (newValue < newMinValue)
                newMinValue = newValue;
            
            _x = x + i;
            _y = y + delta;
            if (_x < 0 || _x >= N || _y < 0 || _y >= N)
                continue;
            
            mat[_x, _y] = newValue;
        }
        
        for (int j = -delta + 1; j < delta; j++)
        {
            var newValue = lastMinValue - rand.Next(1, 6);
            if (newValue < newMinValue)
                newMinValue = newValue;
            
            _x = x - delta;
            _y = y + j;
            if (_x < 0 || _x >= N || _y < 0 || _y >= N)
                continue;
            
            mat[_x, _y] = newValue;
        }
        
        for (int j = -delta + 1; j < delta; j++)
        {
            var newValue = lastMinValue - rand.Next(1, 6);
            if (newValue < newMinValue)
                newMinValue = newValue;
            
            _x = x + delta;
            _y = y + j;
            if (_x < 0 || _x >= N || _y < 0 || _y >= N)
                continue;
            
            mat[_x, _y] = newValue;
        }
        delta++;
        lastMinValue = newMinValue;
    }

    return mat;
}

void MostrarMatrizCebola(int[,] mat)
{
    int N = (int)Math.Sqrt(mat.LongLength);
    StringBuilder sb = new StringBuilder();
    for (int j = 0; j < N; j++)
    {
        if (j == 0)
        {
            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                    sb.Append("┌");
                else sb.Append("┬");
                sb.Append("───────");
            }
            sb.Append("┐\n");
        }
        else
        {
            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                    sb.Append("├");
                else sb.Append("┼");
                sb.Append("───────");
            }
            sb.Append("┤\n");
        }

        for (int k = 0; k < 2; k++)
        {
            for (int i = 0; i < N; i++)
            {
                sb.Append("│");
                sb.Append("       ");
            }
            sb.Append("|\n");
        }
        

        for (int i = 0; i < N; i++)
        {
            sb.Append("│");
            sb.Append(mat[i, j].ToString("  000  "));
        }
        sb.Append("|\n");

        for (int k = 0; k < 2; k++)
        {
            for (int i = 0; i < N; i++)
            {
                sb.Append("│");
                sb.Append("       ");
            }
            sb.Append("|\n");
        }
    }
        
    for (int i = 0; i < N; i++)
    {
        if (i == 0)
            sb.Append("└");
        else sb.Append("┴");
        sb.Append("───────");
    }
    sb.Append("┘\n");
    Console.WriteLine(sb.ToString());
}

void MostrarTempo(int N, int K)
{
    List<int[,]> list = new List<int[,]>();
    Console.Write($"Gerando {K} matrizes para testes: ");
    for (int k = 0; k < K; k++)
    {
        Console.Write($"{k + 1}.. ");
        list.Add(GerarMatrizCebola(N));
    }
    Console.WriteLine("\n");
    
    Stopwatch sw = new Stopwatch();

    Console.WriteLine("Testando solucao1...");
    sw.Start();
    foreach (var mat in list)
    {
        solucao1(mat, N);
    }
    sw.Stop();
    Console.WriteLine($"Solução 1 para n = {N}: {(double)sw.ElapsedMilliseconds / (double)K} ms / execução\n");
    sw.Reset();

    Console.WriteLine("Testando solucao2...");
    sw.Start();
    foreach (var mat in list)
    {
        solucao2(mat, N);
    }
    sw.Stop();
    Console.WriteLine($"Solução 2 para n = {N}: {(double)sw.ElapsedMilliseconds / (double)K} ms / execução\n");
    sw.Reset();

    Console.WriteLine("Testando solucao3...");
    sw.Start();
    foreach (var mat in list)
    {
        solucao3(mat, N);
    }
    sw.Stop();
    Console.WriteLine($"Solução 3 para n = {N}: {(double)sw.ElapsedMilliseconds / (double)K} ms / execução\n");
    sw.Reset();

    Console.WriteLine("Testando solucao4...");
    sw.Start();
    foreach (var mat in list)
    {
        solucao4(mat, N);
    }
    sw.Stop();
    Console.WriteLine($"Solução 4 para n = {N}: {(double)sw.ElapsedMilliseconds / (double)K} ms / execução\n");
    sw.Reset();
}