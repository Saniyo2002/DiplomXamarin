using App2.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static App2.MainPage;

namespace App2.Api
{
    public interface IRestApi
    {
        [Get("/api/matheboards")]
        Task<List<Matheboard>> GetMatheboards();

        [Get("/api/processors")]
        Task<List<Processor>> GetProcessors();
        [Get("/api/sockettype")]
        Task<List<SocketType>> GetSocketType();
        [Get("/api/ram")]
        Task<List<Rams>> GetRams();
        [Get("/api/case")]
        Task<List<Cases>> GetCases();
        [Get("/api/HardDisk")]
        Task<List<HardDisks>> GetHdds();
        [Get("/api/PowerCase")]
        Task<List<PowerCases>> GetPowerCases();
        [Get("/api/ssd")]
        Task<List<SolidStateDrives>> GetSsds();
        [Get("/api/SsdM2")]
        Task<List<M2>> GetM2s();
        [Get("/api/videocard")]
        Task<List<Videocards>> GetVideocards();
        [Get("/api/manufacture")]
        Task<List<Manufacturers>> GetManufacturers();
        [Get("/api/ramtype")]
        Task<List<RamType>> GetRamTypes();
        [Post("/api/SaveBuild")]
        Task <ApiResponse<ApiResult>> PostSaveBuild([Body]ClientComponent clientComponent);
        [Get("/api/SaveBuild")]
        Task<List<ClientComponent>> GetBasket();

        [Post("/Login/Authorization")]
        Task<ApiResponse<AuthResponseToken>> Authorization(string login, string password);
        [Post("/api/PasswordRecovery")]
        Task <ApiResponse<AuthResponseToken>> RecoveryPassword(string login, string email, string dateTime);
        [Get("/api/PasswordRecovery/newPassword")]
        Task<ApiResponse<AuthResponseToken>> NewPassword(string login, string oldPassword, string newPassword);
        [Post("/Registration/Registration")]
        Task<ApiResponse<AuthResponseToken>> Registration(Clients clients);
        [Post("/api/BuildDelete")]
        Task <ApiResponse<ApiResult>> RemoveBuildClient(int idBuild);


    } }
