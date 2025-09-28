# 使用官方 .NET 运行时镜像作为基础镜像
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8002

# 使用官方 .NET SDK 镜像作为构建镜像
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MHZNet.Api/MHZNet.Api.csproj", "MHZNet.Api/"]
COPY ["MHZNet.Business/MHZNet.Business.csproj", "MHZNet.Business/"]
COPY ["MHZNet.Common/MHZNet.Common.csproj", "MHZNet.Common/"]
COPY ["MHZNet.Core/MHZNet.Core.csproj", "MHZNet.Core/"]
COPY ["MHZNet.Entity/MHZNet.Entity.csproj", "MHZNet.Entity/"]
COPY ["MHZNet.EventBus/MHZNet.EventBus.csproj", "MHZNet.EventBus/"]
COPY ["MHZNet.IBusiness/MHZNet.IBusiness.csproj", "MHZNet.IBusiness/"]
COPY ["MHZNet.Infrastructure/MHZNet.Infrastructure.csproj", "MHZNet.Infrastructure/"]
COPY ["MHZNet.Repository/MHZNet.Repository.csproj", "MHZNet.Repository/"]
COPY ["MHZNet.SharedModel/MHZNet.SharedModel.csproj", "MHZNet.SharedModel/"]
COPY ["MHZNet.TaskService/MHZNet.TaskService.csproj", "MHZNet.TaskService/"]
COPY ["MHZNet.ViewModel/MHZNet.ViewModel.csproj", "MHZNet.ViewModel/"]
RUN dotnet restore "MHZNet.Api/MHZNet.Api.csproj"

COPY . .
WORKDIR "/src/MHZNet.Api"
RUN dotnet build "MHZNet.Api.csproj" -c Release -o /app/build

# 发布应用
FROM build AS publish
RUN dotnet publish "MHZNet.Api.csproj" -c Release -o /app/publish

# 运行阶段
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MHZNet.Api.dll"]
