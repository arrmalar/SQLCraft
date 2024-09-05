﻿using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using SQLCraftFront.Models;
using SQLCraftFront.Repositories.IRepositories;
using System.Data;
using System.Xml.Linq;

namespace SQLCraftFront.Repositories
{
    public class QueryRiddleRepository : IQueryRiddleRepository
    {
        private readonly HttpClient _httpClient;

        public QueryRiddleRepository(HttpClient httpClient) {
            _httpClient = httpClient;
        }  

        public async Task<QueryRiddleDTO> Get(int ID)
        {
            string url = $"https://localhost:7048/api/queryRiddle/get/{ID}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var queryRiddleDTO = await response.Content.ReadFromJsonAsync<QueryRiddleDTO>();
                    return queryRiddleDTO;
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                    return new QueryRiddleDTO();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new QueryRiddleDTO();
            }
        }

        public async Task<List<QueryRiddleDTO>> GetAll()
        {
            string url = "https://localhost:7048/api/queryRiddle/getAll";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var queryRiddleDTOs = await response.Content.ReadFromJsonAsync<List<QueryRiddleDTO>>();
                    return queryRiddleDTOs;
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                    return new List<QueryRiddleDTO>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<QueryRiddleDTO>();
            }
        }

        public async Task Update(QueryRiddleDTO queryRiddleDTO)
        {
            string url = "https://localhost:7048/api/queryRiddle/update";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(queryRiddleDTO),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await _httpClient.PutAsync(url, jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task Delete(int ID)
        {
            string url = $"https://localhost:7048/api/queryRiddle/delete/{ID}";

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task Save(QueryRiddleDTO queryRiddleDTO)
        {
            string url = "https://localhost:7048/api/queryRiddle/save";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(queryRiddleDTO),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await _httpClient.PostAsync(url, jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
