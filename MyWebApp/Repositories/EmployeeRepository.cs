using Dapper;
using MyWebApp.Models;

namespace MyWebApp.Repositories
{
    public class EmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var query = "SELECT * FROM Employee";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Employee>(query);
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Employee WHERE EmpId = @EmpId";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Employee>(query, new { EmpId = id });
        }

        public async Task AddAsync(Employee employee)
        {
            var query = "INSERT INTO Employee (Name, Salary) VALUES (@Name, @Salary)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, employee);
        }

        public async Task UpdateAsync(Employee employee)
        {
            var query = "UPDATE Employee SET Name = @Name, Salary = @Salary WHERE EmpId = @EmpId";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, employee);
        }

        public async Task DeleteAsync(int id)
        {
            var query = "DELETE FROM Employee WHERE EmpId = @EmpId";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { EmpId = id });
        }
    }

}
