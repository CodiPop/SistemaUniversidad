import React from 'react'
import Layout from '../layout/Layout';
import Home from '../pages/Home';
import Edit from '../pages/Edit';
import EditA from '../pages/EditA';
import EditD from '../pages/EditD';
import {BrowserRouter as Router, Route,Routes} from "react-router-dom"

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
{/*             <Route exact path="/Form" element={<Form/>}/>
            <Route exact path="/Lista" element={<Lista/>}/>
            <Route exact path="/User/:id" element={<User/>}/>
             */}
            
          </Routes> 
        </Layout>
      </Router>
      
      </React.Fragment>
    )
  
}


export default App


