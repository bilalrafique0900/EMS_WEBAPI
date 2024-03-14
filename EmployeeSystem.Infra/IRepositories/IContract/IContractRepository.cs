namespace EmployeeSystem.Infra.IRepositories.IContract
{
    public interface IContractRepository
    {
        Task<string> GetStudentContract(string Contact, Guid StudentId);
        
    }
}
