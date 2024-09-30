import { Api } from "@sheduler/sdk"
import { Monkey } from "./monkey.js";
import { createServer } from "http";

// const api = new Api("http://localhost:5013");
const api = new Api("https://sheduler-api-dev.web.app");

const port = 3000;

const monkey = new Monkey(api, `https://c61a-91-126-65-143.ngrok-free.app`);

const server = createServer();
server.addListener('request', (req, res) => {
    console.log({
        path: req.url, 
        headers: {...req.headers}
    });
    res.writeHead(204);
    res.end();
})
server.listen(port, '0.0.0.0');
