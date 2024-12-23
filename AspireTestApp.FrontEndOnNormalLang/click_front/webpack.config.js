const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const webpack = require('webpack');

const ROOT = path.resolve(__dirname, 'src');
const DESTINATION = path.resolve(__dirname, 'dist');

module.exports = (env) => {
  return {
    entry: {
      'main': './src/index.tsx'
    },
    output: {
      filename: '[name].bundle.js',
      path: DESTINATION
    },
    resolve: {
      extensions: ['.ts', '.tsx', '.js', '.json']
    },
    plugins: [
      new HtmlWebpackPlugin({
        template: './src/index.html'
      })
    ],
    module: {
      rules: [
        {
          test: /\.tsx?$/,
          use: 'ts-loader',
          exclude: /node_modules/,
        },
        {
          test: /\.css$/i,
          use: ["style-loader", "css-loader"],
        },
      ]
    },
    
    devtool: 'cheap-module-source-map',
    devServer:
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
  }
};