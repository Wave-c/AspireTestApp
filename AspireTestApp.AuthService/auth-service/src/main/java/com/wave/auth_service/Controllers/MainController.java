package com.wave.auth_service.Controllers;

import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class MainController 
{
    @GetMapping("/hello")
    public ResponseEntity<?> Hello(@RequestParam String username)
    {
        return ResponseEntity.ok().body("Hello " + username);
    }
}
