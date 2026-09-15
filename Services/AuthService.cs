using AIUBBusManagementSystem.Models;
using AIUBBusManagementSystem.Repositories;
using System;

namespace AIUBBusManagementSystem.Services
{
    internal class AuthService
    {
        private readonly UserRepository userRepository;

        public AuthService()
        {
            userRepository = new UserRepository();
        }

        // Login user with username and password
        public User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            User user = userRepository.GetByUsernameAndPassword(
                username,
                password
            );

            if (user == null)
            {
                return null;
            }

            // Students can login only after admin approval
            if (user.Role == "Student" && user.Status != "Active")
            {
                return null;
            }

            // Blocked users are not allowed to login
            if (user.Status == "Blocked")
            {
                return null;
            }

            return user;
        }

        // =====================================================
        // FORGOT PASSWORD
        // =====================================================

        public bool ResetPassword(string username, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(newPassword))
            {
                return false;
            }

            return userRepository.UpdatePassword(
                username.Trim(),
                newPassword
            );
        }
    }
}