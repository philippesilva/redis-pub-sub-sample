import { createClient } from "redis";

(async () => {
  const client = createClient({
    url: "redis://localhost:6379",
  });

  console.log("Sub...");

  const subscriber = client.duplicate();

  await subscriber.connect();

  await subscriber.subscribe("channel-name", (message) => {
    console.log(message); // 'message'
  });
})();
