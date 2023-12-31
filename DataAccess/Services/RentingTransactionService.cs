﻿using BusinessObjects.Entities;
using DataAccess.Repositories;

namespace DataAccess.Services {
    public class RentingTransactionService : IRentingTransactionService {
        private readonly IRentingTransactionRepository _rentingTransactionRepository;


        public RentingTransactionService(IRentingTransactionRepository rentingTransactionRepository) {
            _rentingTransactionRepository = rentingTransactionRepository;
        }

        public Task<List<RentingTransaction>> GetTransactionsByCustomerEmail(string customerEmail) {
            try {
                Task<List<RentingTransaction>> result =
                    _rentingTransactionRepository.GetTransactionsByCustomerEmail(customerEmail);
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<RentingDetail>> GetRentingDetails() {
            try {
                Task<List<RentingDetail>> result = _rentingTransactionRepository.GetRentingDetails();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<RentingTransaction>> GetRentingTransactions() {
            try {
                Task<List<RentingTransaction>> result = _rentingTransactionRepository.GetRentingTransactions();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}