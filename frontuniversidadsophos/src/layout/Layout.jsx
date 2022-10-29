import React from 'react'
import Footer from '../components/Footer'
import Header from '../components/Header'


const Layout = (props) => {
  return (
    <React.Fragment>
        <Header/>
        
        {props.children}
     
        <Footer/>
    </React.Fragment>
  )
}

export default Layout