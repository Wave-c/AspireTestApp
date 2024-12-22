import React, { createContext } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import ReactDOM from 'react-dom/client';
import './index.css';
import MainWindow from './Components/MainWindow/MainWindow.tsx';
import Store from './Store/Store.ts';


const store = new Store();

export const Context = createContext({
  store
});

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <Context.Provider value={{
    store
  }}>
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<MainWindow/>}/>
      </Routes>
    </BrowserRouter>
  </Context.Provider>
);
