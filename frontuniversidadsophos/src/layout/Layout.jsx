import { Container } from '@mui/material'
import React from 'react'
import Footer from '../components/Footer'
import Header from '../components/Header'


const Layout = (props) => {
  return (
    <React.Fragment>
        <Header/>
        <Container maxWidth="lg">{props.children}</Container>
     
        <Footer/>
    </React.Fragment>
  )
}

export default Layout