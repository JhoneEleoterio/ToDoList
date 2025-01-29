FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /src
COPY ["tests/WebAPI.Tests/WebAPI.Tests.csproj", "tests/WebAPI.Tests/"]
COPY ["src/WebAPI/WebAPI.csproj", "src/WebAPI/"]
RUN dotnet restore "tests/WebAPI.Tests/WebAPI.Tests.csproj"

COPY . .
WORKDIR "/src/tests/WebAPI.Tests"
ENTRYPOINT ["dotnet", "test", "--logger:console;verbosity=detailed"]