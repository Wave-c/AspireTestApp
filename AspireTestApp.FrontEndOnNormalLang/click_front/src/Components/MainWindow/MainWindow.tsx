import BodyComp from "../Body/BodyComp";
import "./MainWindow.css"
import React from 'react';
import { FC, useContext, useEffect, useState} from 'react';
import { observer } from 'mobx-react-lite';
import { Context } from "../../index";
import User from "../../Models/User";


const MainWindow : FC = () =>
{
    const [id, setid] = useState("Нету(");
    const {store} = useContext(Context);

    store.setUser(new User())

    try
    {
        useEffect(() => 
        {
            console.log(store.getIsAuth())
            if(!store.isAuth)
            {
                setid("Нету(");
            }
            else
            {
                setid(store.getUser().Id);
            }
        }, [store.isAuth]);
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