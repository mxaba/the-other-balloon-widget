import React, { useState } from 'react';
import { Route } from 'react-router';
import AlertComponent from './components/AlertComponent/AlertComponent';
import { Layout } from './components/Layout';
import  Home  from './components/Home';

import './custom.css'
import Chat from './components/ChatHub/Chat';

const App = () => {
  const [errorMessage, updateErrorMessage] = useState(null);
  // render () {
    return (
      <Layout>
        <Route exact path='/' render={(props) => <Home updateErrorMessage={updateErrorMessage} {...props}/>} />
        <Route path='/chatHub' render={(props) => <Chat updateErrorMessage={updateErrorMessage} {...props}/>} />
        {/* <Route path='/fetch-data' component={FetchData} /> */}
        <AlertComponent errorMessage={errorMessage} hideError={updateErrorMessage}/>
      </Layout>
      
    );
  // }
}

export default App;
