import React, { useState } from 'react';
import { Route } from 'react-router';
import AlertComponent from './components/AlertComponent/AlertComponent';
import { Layout } from './components/Layout';
import  Home  from './components/Home';

import './custom.css'

const App = () => {
  const [errorMessage, updateErrorMessage] = useState(null);
  // render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        {/* <Route path='/counter' component={Counter} /> */}
        {/* <Route path='/fetch-data' component={FetchData} /> */}
        <AlertComponent errorMessage={errorMessage} hideError={updateErrorMessage}/>
      </Layout>
      
    );
  // }
}

export default App;
