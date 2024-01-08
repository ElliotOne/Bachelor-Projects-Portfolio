const hbs = require("hbs");
const fs = require("fs");
const path = require('path');
const formidable = require("formidable")
const bodyParser = require("body-parser");
const express = require("express");
const mysql = require("mysql2");
const bcrypt = require("bcryptjs");
const app = express();
const session = require('express-session');

app.use(session({
    secret: 'mytext',
    resave: true,
    saveUninitialized: true
}));
app.use(express.static('public'));
app.use(bodyParser.urlencoded({ extended: true }));
app.set('view engine', 'hbs');
let connection = mysql.createConnection({
    host: 'localhost',
    port: 1111,
    user: 'root',
    password: '',
    database: 'studentblog'
});

/*===================================
                Get
===================================*/

app.get("/", (req, res) => {
    res.render("home");
});
app.get("/signin", (req, res) => {
    res.render("signin");
});
app.get("/signup", (req, res) => {
    res.render("signup");
});
app.get("/signout", (req, res) => {

    req.session.user = undefined;
    req.session.type = undefined;
    res.redirect("/");
});
app.get("/blog", (req, res) => {

    //user => id
    //blog => id
    // id = ?!?!
    connection.query('select *,blogpost.id from blogpost join user on blogpost.user_id = user.id', [], async (err, result, field) => {

        res.render("blog", { posts: result });
    });
})
app.get("/panel", (req, res) => {
    res.render("panel/panel", { lblusername: req.session.user });
})
app.get("/posts", (req, res) => {

    let userid = req.session.userid;

    connection.query('select *,blogpost.id from blogpost join user on blogpost.user_id = user.id where user.id = ?', [userid], async (err, result, field) => {
        res.render("panel/posts", { posts: result });
    });
})
app.get("/addPost", (req, res) => {
    res.render("panel/posts_add");
})
app.get("/blogonepost", (req, res) => {

    let id = req.query.id;

    connection.query('select *,blogpost.id from blogpost join user on blogpost.user_id = user.id where blogpost.id = ?', [id], async (err, result, field) => {


        connection.query('select * from comment join user on comment.user_id = user.id where comment.isOk = 1', [id], async (err2, result2, field2) => {

            let userid = req.session.userid;

            res.render("blogpost", { singlepost: result, currentuser: userid, comments: result2 });
        });

    });
})
app.get("/deletePost", (req, res) => {
    let id = req.query.id;

    connection.query('delete from blogpost where id = ?', [id], async (err, result, field) => {
        res.redirect("/posts");
    });



})
app.get("/comments", (req, res) => {

    connection.query('select * ,comment.id from comment join user on comment.user_id = user.id', [], async (err, result, field) => {

        res.render("panel/comments", { comments: result });
    });

})
app.get("/deleteComment", (req, res) => {
    let id = req.query.id;

    connection.query('delete from comment where id = ?', [id], async (err, result, field) => {
        console.log(result);
        res.redirect("/comments");
    });
})
app.get("/acceptComment", (req, res) => {
    let id = req.query.id;
    connection.query('update comment set isOk = 1 where id = ?', [id], async (err, result, field) => {

        res.redirect("/comments");
    });
})





/*===================================
                Post
===================================*/

app.post("/signinform", (req, res) => {

    const username = req.body.username;
    const password = req.body.password;

    connection.query('select username,password,isstudent,id from user', [], async (err, result, field) => {
        let flag = false;
        if (err) console.log(err)
        else {
            for (i = 0; i < result.length; i++) {
                if (result[i]['username'] == username) {
                    let hashedPassword = result[i]['password'];
                    console.log(hashedPassword);
                    let isTrueHash = await compareHash(password, hashedPassword);

                    if (isTrueHash) {
                        req.session.user = username;
                        req.session.isstudent = result[i]['isstudent'];
                        req.session.userid = result[i]['id'];
                        flag = true;
                    }
                }
            }
            if (flag)
                //res.render("index", { username: req.session.user, type: req.session.type });

                if (req.session.isstudent == 1) {
                    res.redirect("/blog");
                }
                else {
                    res.redirect("/panel");
                }

            else
                res.render("signin", { status: "نام کاربری یا رمز عبور اشتباه است!" });
        }
    });
});
let compareHash = (pass, hashedpass) => {
    return new Promise((resolve, reject) => {
        bcrypt.compare(pass, hashedpass, (err, res) => {
            if (err) reject(err);
            resolve(res);
        });
    });
}
app.post("/signupform", async (req, res) => {

    firstname = req.body.firstname;
    lastname = req.body.lastname;
    username = req.body.username;
    usertype = req.body.usertype;

    if (usertype === "student") {
        usertype = 1;
    } else {
        usertype = 0;
    }

    password = req.body.password;
    description = req.body.description;
    email = req.body.email;

    let flag = await checkUnic(username);
    if (!flag) {

        let hash = await genHash(password);
        connection.query("insert into user (firstname,lastname,username,password,isstudent,description,email) values(?,?,?,?,?,?,?)"
            , [firstname, lastname, username, hash, usertype, description, email],
            (err, result, field) => {
                if (err) console.log(err);
                else {
                    req.session.user = username;
                    req.session.isstudent = usertype;
                    fs.mkdir(__dirname + "/public/postfiles/" + username, () => {
                        res.redirect("/");
                    })
                }
            });
    }
    else
        res.render("signup", { status_submit: "کاربری با این نام از قبل موجود است!" });
});
let checkUnic = (username) => {
    return new Promise((resolve, reject) => {

        connection.query("select * from user where username = '" + username + "' ", [], (err, result, field) => {
            flag = false;
            if (err) reject(err);
            else {
                if (result.length > 0) flag = true;
                resolve(flag);
            }
        });
    });
}
let genHash = (password) => {
    return new Promise((resolve, reject) => {
        bcrypt.genSalt(10, (err, salt) => {
            if (err) reject(err);
            bcrypt.hash(password, salt, (err, hash) => {
                if (err) reject(err);
                resolve(hash);
            });
        });
    });
}
let copyUploadedfile = (oldpath, newpath) => {

    return new Promise((resolve, reject) => {
        // Extract the directory path from the newpath
        const dirname = path.dirname(newpath);

        // Check if the directory exists, create it if not
        if (!fs.existsSync(dirname)) {
            fs.mkdirSync(dirname, { recursive: true });
        }

        // Copy the file
        fs.copyFile(oldpath, newpath, (err) => {
            if (err) {
                reject(err);
            } else {
                resolve(newpath);
            }
        });
    });
}
app.post("/insertPostform", (req, res) => {

    if (!req.session.user) res.redirect('/');
    let username = req.session.user;
    var form = new formidable.IncomingForm();
    form.parse(req, async (err, fields, files) => {
        let filepath = files['file']['path'];
        let filename = files['file']['name'];

        let picpath = files['picture']['path'];
        let picname = files['picture']['name'];

        let newpicpath = __dirname + "/public/blogposts/" + req.session.user + "/" + files['picture']['name'];
        let newfilepath = __dirname + "/public/blogposts/" + req.session.user + '/' + files['file']['name'];

        if (files['picture']['size'] > 0) {
            if (files['picture']['type'].includes('image'))
                await copyUploadedfile(picpath, newpicpath);
        }
        if (files['file']['size'] > 0) {
            await copyUploadedfile(filepath, newfilepath);
        }
        else
            filename = "";
        connection.query("Select username,id from user", [], (err2, results, field) => {

            for (i = 0; i < results.length; i++) {
                if (results[i]['username'] == username) {
                    const userid = results[i]['id'];
                    const text = fields['text'];
                    const title = fields['title'];
                    let postDate = getMyDate(new Date());
                    console.log(postDate);
                    connection.query("insert into blogpost (user_id,pictureaddress,title,body,senddate,fileaddress) values(?,?,?,?,?,?)",
                        [userid, picname, title, text, postDate, filename], (err3, results2, field2) => {
                            if (err3) console.log(err3);
                            res.redirect("/posts");
                        });
                    break;
                }
            }
        });

    });

});


let getMyDate = (date) => {
    var year = date.getFullYear(),
        month = date.getMonth() + 1,
        day = date.getDate(),
        hour = date.getHours(),
        minute = date.getMinutes(),
        second = date.getSeconds(),
        hourForm = hour % 12 || 12,
        minuteForm = minute < 10 ? "0" + minute : minute;

    return year + "-" + month + "-" + day + " " + hourForm + ":" + minuteForm + ":" + second;
}



app.post("/insertCommentform", (req, res) => {
    let userid = req.body.user_id;
    let postid = req.body.post_id;
    let senddate = getMyDate(new Date());
    connection.query("insert into comment (blogpost_id,user_id,commentText,senddate,isOk) values (?,?,?,?,?)",
        [postid, userid, req.body.commentText, senddate, 0], (err, results, field) => {
            console.log(results);
            res.redirect("/blogonepost?id=" + postid);
        });

})


app.listen(5000);