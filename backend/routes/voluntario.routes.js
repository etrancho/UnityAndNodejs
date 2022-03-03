module.exports = app => {
    const voluntario = require("../controllers/voluntario.controller.js");
    //const auth = require("../controllers/auth.js");
    var router = require("express").Router();

    // Create a new one
    router.post("/", 
    //auth.isAuthenticated, 
    voluntario.create);
    // Retrieve all ones
    router.get("/", 
    //auth.isAuthenticated, 
    voluntario.findAll);
    // Retrieve a single one with id
    router.get("/:id", 
    //auth.isAuthenticated, 
    voluntario.findOne);
    // Update one with id
    router.put("/:id", 
    //auth.isAuthenticated, 
    voluntario.update);
    // Delete one with id
    router.delete("/:id", 
    //auth.isAuthenticated, 
    voluntario.delete);

    app.use('/voluntarios', router);
};