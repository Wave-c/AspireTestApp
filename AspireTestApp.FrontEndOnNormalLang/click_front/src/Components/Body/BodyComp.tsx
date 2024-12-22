import React from 'react';
import "./BodyComp.css"

export default function BodyComp(props)
{
    return (
        <div class="container text-center mt-4">
            <p class="display-4">Clicks: {}</p>
            <button class="btn btn-primary btn-lg me-3">Click Me!</button>
            <button class="btn btn-danger btn-lg">Reset</button>
            <button>submit</button>
        </div>
    )
}