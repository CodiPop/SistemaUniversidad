import { useState } from "react"

export const useGetMore2 = () =>{
    const [data2,setData2] = useState(0)
    const [data3,setData3] = useState([])

    const addData2 = (data) => {
        const datas = data;
        setData2(datas)
    }
    

    const addData3 = (data) => {
        const datas = data;
        setData3(datas)
    }

return{
    data2,
    addData2,data3,addData3
}
}