const proxy = [
  {
    context: '/api',
    target: 'http://localhost:7491',
    pathRewrite: {'^/api' : ''}
  }
];
module.exports = proxy;