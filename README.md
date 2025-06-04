# Orchestrator Service

- This service is the connector between the bot and the microservices, as well as microservices to eachother

```/slash-commands/info ```

```/slash-commands/news ```

```/slash-commands/price-data ```

- The api returns an object like this.

```csharp 
{
  message: string,
  data: object
} 
```

- All these commands take a query param of ticker which is the ticker passed into the client.

- This will be the control center of the bot, which will handle gathering data from multiple services, sending data to other services to process, and send the results back to the bot.
