import { createClient } from "redis";
const publisher = createClient({
  url: "redis://localhost:6379",
});

(async () => {
  const message = {
    id: "014193f3-2ee7-4f69-afe3-2211e45184fc",
    content: "Using Redis Pub/Sub with Node.js",
  };

  await publisher.connect();

  await publisher.publish("channel-name", JSON.stringify(message));
})();
