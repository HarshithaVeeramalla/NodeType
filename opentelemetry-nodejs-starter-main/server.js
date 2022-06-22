  
'use strict';

//Dependency

//Configuration
let appInsights = require('applicationinsights');
appInsights.setup("cc580d32-a7eb-41d7-b0e0-90ea0889fd10 ");
appInsights.start();

const PORT = process.env.PORT || 8080;

  //Wrap your application Code
  const express = require('express');
  const app = express();
  app.use(express.json());

  app.get('/', (req, res) => {
    res.send('running...');
  });

  app.get('/ping', (req, res) => {
    console.log(req.rawHeaders);
    res.send('pong');
  });

  app.listen(PORT);
  console.log(`Running on ${PORT}`);