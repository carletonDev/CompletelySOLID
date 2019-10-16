//using create reducer from redux starter kit instead of normal reducer with immer
import { createReducer,createAction } from 'redux-starter-kit';

const add = createAction('addMedicine');
const list = createAction('listMedicine');
const remove =createAction('')