const express = require('express');
const path = require('path');
const app = express();

const port = 3000;

app.get('/', (req, res) => {
  res.sendFile(path.join(__dirname, 'index.html'));
});

app.get('/barrel.html', (req, res) => {
  res.sendFile(path.join(__dirname, 'barrel.html'));
});

app.get('/bird.html', (req, res) => {
  res.sendFile(path.join(__dirname, 'bird.html'));
});

app.listen(port, () => {
  console.log(`Server is running on port ${port}.`);
});