using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using PrimeraAPI.Models;
using System.Reflection.Metadata.Ecma335;


namespace PrimeraAPI.Data
{
    public class ProductoService
    {
        private readonly string _connectionString;

        public ProductoService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("TiendaDB");
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            var productList = new List<Producto>();
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            using var cmd = new SqlCommand("select * from Productos", conn);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                productList.Add(new Producto
                {
                    id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Precio = reader.GetDecimal(2)
                });
            }
            return productList;

        }

        //Obtener un producto por ID
        public async Task<Producto> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand(
                "SELECT * FROM Productos where Id =  @Id", conn
            );
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Producto
                {
                    id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Precio = reader.GetDecimal(2)
                };
            }
            return null;
        }

        //Crear un nuevo propducto
        public async Task<Producto> CreateAsync(Producto producto)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand(
                "INSERT INTO Productos (Nombre, Precio) OUTPUT INSERTED.id VALUES (@Nombre, @Precio)", conn
            );
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);

            var id = (int)await cmd.ExecuteScalarAsync()!;
            producto.id = id;
            return producto;

        }

        public async Task<bool> UpdateAsync(int id, Producto product)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand(
                "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio where Id = @id", conn
            );
            cmd.Parameters.AddWithValue("@Nombre", product.Nombre);
            cmd.Parameters.AddWithValue("@Precio", product.Precio);
            cmd.Parameters.AddWithValue("@id", id);

            var afectedRows = await cmd.ExecuteNonQueryAsync();
            return afectedRows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand(
                "DELETE Productos where Id = @id", conn
            );
            cmd.Parameters.AddWithValue("@id", id);

            var afectedRows = await cmd.ExecuteNonQueryAsync();
            return afectedRows > 0;
        }

    }


}