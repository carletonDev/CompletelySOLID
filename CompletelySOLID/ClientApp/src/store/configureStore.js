import { applyMiddleware, combineReducers, compose, createStore } from 'redux';

import { routerReducer, routerMiddleware } from 'react-router-redux';
import * as Counter from './Counter';
import * as WeatherForecasts from './WeatherForecasts';
import * as Pharmacy from './reducers/Pharmacy'

import thunk from 'redux-thunk';
import * as Medicine from '../store/Medicine';

 export default function configureStore(history, initialState) {
   const reducers = {
     counter: Counter.reducer,
     weatherForecasts: WeatherForecasts.reducer,
     Pharmacy:Pharmacy.reducer,
     Medicine: Medicine.reducer
   };

   const middleware = [
     thunk,
     routerMiddleware(history)
   ];

   // In development, use the browser's Redux dev tools extension if installed
   const enhancers = [];
   const isDevelopment = process.env.NODE_ENV === 'development';
   if (isDevelopment && typeof window !== 'undefined' && window.devToolsExtension) {
     enhancers.push(window.devToolsExtension());
   }

   const rootReducer = combineReducers({
     ...reducers,
     routing: routerReducer
   });

   return createStore(
     rootReducer,
     initialState,
     compose(applyMiddleware(...middleware), ...enhancers)
   );
 }
