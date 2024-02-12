using System;
using System.Threading.Tasks;

namespace PALC;

public delegate Task AsyncEventHandler(object? sender, EventArgs e);
public delegate Task AsyncEventHandler<TEventArgs>(object? sender, TEventArgs e);
