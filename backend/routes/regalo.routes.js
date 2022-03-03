module.exports = app => {
    const regalo = require("../controllers/regalo.controller.js");
    //const auth = require("../controllers/auth.js");
    var router = require("express").Router();

    // Create a new one
    router.post("/", 
    //auth.isAuthenticated, 
    regalo.create);
    // Retrieve all ones
    router.get("/", 
    //auth.isAuthenticated, 
    regalo.findAll);
    // Retrieve a single one with id
    router.get("/:idR", 
    //auth.isAuthenticated, 
    regalo.findOne);
    // Update one with id
    router.put("/:idR", 
    //auth.isAuthenticated, 
    regalo.update);
    // Delete one with id
    router.delete("/:idR", 
    //auth.isAuthenticated, 
    regalo.delete);

    app.use('/regalos', router);
};