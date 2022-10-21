import React from 'react'
import { useLocation } from 'react-router-dom'
import Form from '../components/Form'

const Create = () => {

    const location = useLocation();
    console.log(location.state)

  return (
    <div>
    
    <Form parametro={location.state} />
    </div>
  )
}

export default Create