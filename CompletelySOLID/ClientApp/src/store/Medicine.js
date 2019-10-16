//using create reducer from redux starter kit instead of normal reducer with immer
import{createReducer,createAction} from 'redux-starter-kit'
import Axios from 'axios';

//inital state
const initalState = {medicine:[]};

//creating action  using redux starter kit method

const add = createAction('addMedicine');
const list = createAction('listMedicine')
const remove =createAction('deleteMedicine');
const put =createAction('updateMedicine');
//using create reducer method in redux starter kit to make an immer reducer

export const reducer = createReducer(initalState,{
    [list.type]:(state,action)=>state+action.payload,
    [add.type]:(state,action)=>state+action.payload,
    [remove.type]:(state,action)=>state+action.payload,
    [put.type]:(state,action)=>state+action.payload
})

export const getMedicine=()=>{
    return(dispatch)=>{
        return Axios.get('api/medicine').then(res=>{
            dispatch(list(res.data))
        })
    }
};
export const deleteMedicine=(id)=>{
    return(dispatch)=>{
        return Axios.delete('api/medicine/'+id).then(res=>{
            dispatch(remove(res.data))
        })
    }
};
export const createMedicine=(medicine)=>{
    return(dispatch)=>{
        return Axios.post('api/medicine',medicine).then(res=>{
            dispatch(add(res.data))
        })
    }
};
