import BodyComp from "../Body/BodyComp.tsx";
import "./MainWindow.css"
import React from 'react';
import { FC, useContext, useEffect} from 'react';
import { observer } from 'mobx-react-lite';
import { Context } from "../../index.tsx";


const MainWindow : FC = () =>
{
    const {store} = useContext(Context);
    var id;
    try
    {
        useEffect(() => 
        {
            if(store.user.Id == undefined && localStorage.getItem("id") == null)
            {
                id = "Нету(";
            }
            else
            {
                id = store.user.Id;
            }
        }, [store.user.Id]);
    }
    catch(e)
    {
        console.log(e);
    }
    
    return (
        <div className="main-layout">
            <header>
                <h1>Blazor(Почти) Clicker</h1>
                <button onClick = {() => store.signUp()} >Sign Up</button>
                <button onClick = {() => store.signIn()}>Sign In</button>
                <h4>id: {id}</h4>
            </header>
            <div className="body">
                <BodyComp/>
            </div>
        </div>
    )
}

export default observer(MainWindow);