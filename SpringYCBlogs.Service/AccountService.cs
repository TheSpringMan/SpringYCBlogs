using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SpringYCBlogs.Domain.Models;
using SpringYCBlogs.Infrastructure.Repository;
using SpringYCBlogs.Infrastructure;

namespace SpringYCBlogs.Service
{
    public interface IAccountService
    {
        IQueryable<User> Users { get; }
        void AddUser(User user);

        void UpdateUser(User user);

        User GetUserByEmail(string email);

        User GetUserByName(string userName);

        bool UserExist(Expression<Func<User, bool>> expression);

        IQueryable<Role> Roles { get; }
    }

    public class AccountService : IAccountService
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IUnitOfWork unitOfWork;
        public AccountService(IUserRepository userRepository, IUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<User> Users => this.userRepository.GetAll();

        public IQueryable<Role> Roles
        {
            get { return roleRepository.GetAll(); }
        } 

        public void AddUser(User user)
        {
            this.userRepository.Insert(user);
            this.unitOfWork.Commit();
        }

        public User GetUserByEmail(string email)
        {
            return this.userRepository.GetAll().FirstOrDefault(x => x.Email == email);
        }

        public User GetUserByName(string userName)
        {
            return this.userRepository.FirstOrDefault(x => string.Compare(x.UserName, userName, false) == 0);
        }

        public void UpdateUser(User user)
        {
            this.userRepository.Update(user);
            this.unitOfWork.Commit();
        }

        public bool UserExist(Expression<Func<User, bool>> expression)
        {
            return this.userRepository.Exists(expression);
        }
    }
}
