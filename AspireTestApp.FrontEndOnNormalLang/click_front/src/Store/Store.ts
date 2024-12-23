import User from "../Models/User";
import { makeAutoObservable } from "mobx";
import AuthService from "../Services/AuthService";

export default class Store
{
    private user : User;
    private isAuth = false;

    public constructor()
    {
        this.user = JSON.parse(localStorage.getItem("user"));
        if(this.user !== null)
        {
            this.isAuth = true;
        }
        makeAutoObservable(this);
    }

    public setAuth(bool: boolean)
    {
        this.isAuth = bool;
    }

    public getIsAuth() : boolean
    {
        return this.isAuth;
    }

    public setUser(user : User)
    {
        this.user = user;
    }

    public getUser()
    {
        return this.user;
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
            
            localStorage.setItem("user", JSON.stringify(response.data));
            this.setUser(response.data);
            this.setAuth(true);
        }
        catch(e)
        {
            console.log(e);
        }
    }
}