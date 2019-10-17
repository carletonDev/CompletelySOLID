import Axios from 'axios';
import { list, remove, add, getId } from '../Medicine';
//the entity framework core controller has no title to use when you make the api so when using axios you have to set the data value to the inital value in the promise because it has additional properties
export  const getMedicine = () => {
   const request = axios.get('api/medicine')
    return (dispatch) => {
        request.then(({data})=>{
            console.log(data)
            dispatch(list(data))
        })
    };
}
export const deleteMedicine = (id) => {
    return (dispatch) => {
        return Axios.delete('api/medicine/' + id).then(res => {
            
            dispatch(remove(res.data.id)).then(console.log(res.data));
        });
    };
};
export const GetById = (id) => {
    return (dispatch) => {
        return Axios.get('api/medicine/' + id).then(res => {
            dispatch(getId(res.data))
        })
    }
}
export const createMedicine = (medicine) => {
    return (dispatch) => {
        return Axios.post('api/medicine', medicine).then(res => {
            dispatch(add(res.data));
        });
    };
};
