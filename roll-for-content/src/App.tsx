import Button from '@material-ui/core/Button';
import React from 'react';
import './App.css';
import logo from './logo.svg';
import Second from './Second';
import './styles/main.scss';

const App: React.FC = () => {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p className="home">
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a className="App-link" href="https://reactjs.org" target="_blank" rel="noopener noreferrer">
          Learn React
        </a>
        <Second />
        <Button variant="text" color="primary">
          Sample Button
        </Button>
      </header>
    </div>
  );
};

export default App;
