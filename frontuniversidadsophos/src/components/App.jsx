import React from 'react'
import Layout from '../layout/Layout';
import Home from '../pages/Home';
import Edit from '../pages/Edit';
import EditA from '../pages/EditA';
import EditD from '../pages/EditD';
import {BrowserRouter as Router, Route,Routes} from "react-router-dom"
import Create from '../pages/Create';
import Search from '../pages/Search';

const App = () => {

  
    return (

      <React.Fragment>
      <Router>
        <Layout>
          <Routes>
            <Route exact path="/" element={<Home/>}/>
            <Route exact path='/Edit/' element={<Edit/>}/>
            <Route exact path='/EditA/' element={<EditA/>}/>
            <Route exact path='/EditD/' element={<EditD/>}/>
            <Route exact path='/Create/' element={<Create/>}/>
            <Route exact path='/Search/' element={<Search/>}/>

            
          </Routes> 
        </Layout>
      </Router>
      
      </React.Fragment>
    )
  
}


export default App


