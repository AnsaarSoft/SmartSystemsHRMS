global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using NLog;
global using NLog.Web;
global using System.Text;
global using Microsoft.AspNetCore.Authorization;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;

global using SharedLibrary.Model.EmployeeManagement;
global using SharedLibrary.Model.EmployeeManagement.Master;
global using SharedLibrary.Model.OrganizationManagement;
global using SharedLibrary.Model.SystemManagement;
global using SharedLibrary.ViewModel;

global using SSAPI.Context;
global using SSAPI.Helpers;

global using SSAPI.Repository;
global using SSAPI.Repository.Implementation;
global using SSAPI.Repository.Implementation.Administration;
global using SSAPI.Repository.Implementation.EmployeeManagement;
global using SSAPI.Repository.Implementation.EmployeeManagement.Master;
global using SSAPI.Repository.Interface;
global using SSAPI.Repository.Interface.Administration;
global using SSAPI.Repository.Interface.EmployeeManagement;
global using SSAPI.Repository.Interface.EmployeeManagement.Master;
//global using SSAPI.Repository
