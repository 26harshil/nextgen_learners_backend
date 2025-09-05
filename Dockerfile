FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj explicitly
COPY BrightMindQuizApi.csproj ./
WORKDIR /src
RUN dotnet restore "BrightMindQuizApi.csproj"

# Copy the rest of the source
COPY ./. .

# Publish (specify project)
RUN dotnet publish "BrightMindQuizApi.csproj" -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build / app ./

# Render provides $PORT env variable
ENV ASPNETCORE_URLS=http://+:$PORT
ENTRYPOINT ["dotnet", "BrightMindQuizApi.dll"]