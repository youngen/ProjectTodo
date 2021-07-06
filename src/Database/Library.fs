module Database

open Domain

type Transaction<'a> = Transaction of 'a

module Mock =
    let addTask (task:OpenTask) : Transaction<OpenTask list> = Transaction [task]
    let completeTask at (task:OpenTask) : Transaction<OpenTask list> = Transaction [] 
    let removeTask (taskId:TaskId) : Transaction<OpenTask list> = Transaction []
    let listOpenTasks () : Transaction<OpenTask list> = Transaction []
    let listCompletedTasks () : Transaction<CompletedTask list> = Transaction []
