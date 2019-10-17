//using create reducer from redux starter kit instead of normal reducer with immer
import{createReducer,createAction} from 'redux-starter-kit'

//inital state
const state = { medicine:[ ] };

//creating action  using redux starter kit method

export const add = createAction('addMedicine');
export const list = createAction('listMedicine')
export const remove =createAction('deleteMedicine');
export const put = createAction('updateMedicine');
export const getId = createAction('getMedicineById');
//using create reducer method in redux starter kit to make an immer reducer

export const reducer = createReducer(state,{
    [list.type]:(state,action)=>state+action.payload,
    [add.type]:(state,action)=>state+action.payload,
    [remove.type]:(state,action)=>state+action.payload,
    [put.type]: (state, action) => state + action.payload,
    [getId.type]: (state, action) => state + action.payload
})


