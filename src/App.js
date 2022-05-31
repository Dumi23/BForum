import React from 'react';
import Navbar from './comps/Navbar';
import './App.css';
import Home from './comps/pages/Home';
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import Services from './comps/pages/Services';
import Products from './comps/pages/Products';
import SignUp from './comps/pages/SignUp';

function App() {
  return (
    <>
      <Routes>
        <Navbar />
        <Router>
          <Route path='/' exact component={Home} />
          <Route path='/services' component={Services} />
          <Route path='/products' component={Products} />
          <Route path='/sign-up' component={SignUp} />
        </Router>
      </Routes>
    </>
  );
}

export default App;