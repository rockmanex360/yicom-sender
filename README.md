# yicom-sender

The application is built using .net core 6 console app. Run as a message publisher. The application will publish 20 message at once for every 5 second.

Message Structure

`
    {
        Message: "The message from app",
        Timestamp: "A utc date time with ISO format",
        Priority: 5 // on scale 1 to 10. the more high the more important message
    }
`

## How to install

1. Run a RabbitMq server on docker. you can use this commnand. if rabbitmq is already installed, you can move to the next step.
`docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.12-management`

2. Once done, run restore command on yicom-server.
`dotnet restore`

3. Build the application and run.
`dotnet build` & `dotnet run`