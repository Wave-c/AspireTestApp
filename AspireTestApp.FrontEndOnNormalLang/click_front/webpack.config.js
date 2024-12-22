const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = (env) => {
    return {
  entry: './src/index.tsx',
  devServer :
  {
    port: env.PORT || 3000,
    proxy: [
        {
          context: ["/api"],
          target:
            process.env.services__clickerApi__https__0 ||
            process.env.services__clickerApi__http__0,
          pathRewrite: { "^/api": "" },
          secure: false,
        },
      ]
  },
  output: {
    filename: 'bundle.js',
    path: path.resolve(__dirname, 'dist')
  },
  resolve: {
    extensions: ['.tsx', '.ts', '.js']
  },
  plugins: [
    new HtmlWebpackPlugin({
      template: './src/index.html'
    })
  ],
  module: {
    rules: [
      {
        test: '/\.(js|jsx)$/',
        exclude: /node_modules/,
        use: 'babel-loader'
      }
    ]
  }}
};