import { useState } from "react"

export const useGetMore = () =>{
    const [data, setData] = useState([])

    const addData = (data) => {
        const dataa = data;
        setData(dataa)
    }
    
return{
    data,
    addData
}
}