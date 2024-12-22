import User from "../Models/User";
import { makeAutoObservable } from "mobx";
import AuthService from "../Services/AuthService.ts";

export default class Store
{
    user : User;
    isAuth = false;

    constructor()
    {
        makeAutoObservable(this);
    }

    setAuth(bool: boolean)
    {
        this.isAuth = bool;
    }

    setUser(user : User)
    {
        this.user = user;
    }

    async signIn(id : string)
    {
        try
        {
            const response = await AuthService.signIn(localStorage.getItem("id"));
            this.setUser(response.data);
            this.setAuth(true);
        }
        catch(e)
        {
            console.log(e);
        }
    }

    async signUp()
    {
        try
        {
            const response = await AuthService.signUp();
            localStorage.setItem("id", response.data.Id);
            this.setUser(response.data);
            this.setAuth(true);
        }
        catch(e)
        {
            console.log(e);
        }
    }
}