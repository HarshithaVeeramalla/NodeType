import * as express from 'express';
import { AddressInfo } from "net";
import * as path from 'path';

import routes from './routes/index';
import users from './routes/user';

'use strict';
var http = require('http');
var port = process.env.PORT || 1337;

http.createServer(function (req, res) {
    res.writeHead(200, { 'Content-Type': 'text/plain' });
    res.end('Hello World\n');
}).listen(port);

//const express = require('express');
const server = express();

server.get('/', (req, res) => {
    res.send('root:: Azure Express Web Server Successful!');
});


server.listen(4242, () => {
    console.log('Express Test is Running...');
});