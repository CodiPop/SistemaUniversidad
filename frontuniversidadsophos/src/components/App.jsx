import React from 'react'
import Layout from '../layout/Layout';
import {BrowserRouter as Router, Route,Routes} from "react-router-dom"

const App = () => {

  
    return (

      <React.Fragment>
      <Router>
        <Layout>
     {/*      <Routes>
            <Route exact path="/" element={<Home/>}/>
            <Route exact path="/Form" element={<Form/>}/>
            <Route exact path="/Lista" element={<Lista/>}/>
            <Route exact path="/User/:id" element={<User/>}/>
            <Route exact path="/Edit/:id" element={<Edit/>}/>
            
          </Routes> */}
        </Layout>
      </Router>
      
      </React.Fragment>
    )
  
}


export default App


